using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color noMoney;
    public Vector3 positionOffset;

    [Header("Pig info")]
    public GameObject pigPrefab;
    public Transform pigSpawnPoint;
    private Animation animationPig;
    public float buildDuration = 3;

    private MeshRenderer meshRend;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;


    private BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        meshRend = GetComponent<MeshRenderer>();
        animationPig = pigPrefab.GetComponent<Animation>();
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        
        GameObject _pig = (GameObject)Instantiate(pigPrefab, this.transform.position, Quaternion.identity);
       // Vector3 dir = this.transform.position - pigSpawnPoint.transform.position;
        //animationPig.Play("mixamo.com");
        
        //_pig.transform.Translate(dir.normalized * 10 * Time.deltaTime, Space.World);


        //***********************
        //_pig.transform.LookAt(this.transform);
        //animationPig.Stop();


        animationPig.Play("mixamo.com (1)");
        StartCoroutine(StartBuild(blueprint, _pig));
        
    }

    IEnumerator StartBuild(TurretBlueprint blueprint, GameObject pig)
    {
        yield return new WaitForSeconds(blueprint.timeToBuild);
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build! Money left: " + PlayerStats.Money.ToString());
        animationPig.Stop();
        Destroy(pig);

    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

       
        if(turret != null)
        {
            Debug.Log("We cant place this");
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        
        BuildTurret(buildManager.GetTurretToBuild());

    }

	void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            return;
        }

        if (buildManager.CanHover)
        {
            meshRend.enabled = true;
            rend.material.color = hoverColor;
        }
        else
        {
            meshRend.enabled = true;
            rend.material.color = noMoney;
        }
        
    }


    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);


        //Build new
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded!");
    }


    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //TODO: Effect
        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseExit()
    {
        meshRend.enabled = false;
        rend.material.color = startColor;
    }

    
}
