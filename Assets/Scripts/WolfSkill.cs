using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSkill : MonoBehaviour
{

    private Transform target;
    public float explosionRadius = 0f;
    public int damage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
        HitTarget();
    }

    void Update()
    {
        if (target == null)
        {
            //Destroy(gameObject);
            return;
        }

        
    }


    private void HitTarget()
    {
        Debug.Log("WE HIT SOMETHING");
        

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        //Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliedrs = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliedrs)
        {
            if (collider.tag == "Turret")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Turret e = enemy.GetComponent<Turret>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

