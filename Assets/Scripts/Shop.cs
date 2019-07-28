using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    
    

    BuildManager buildManager;

    private GameObject tempObject;
    
    void Start()
    {
        buildManager = BuildManager.instance;
    }
	public void SelectStandartTurret()
    {
        Debug.Log("Standart turret");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile lancher esletced");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer esletced");
        buildManager.SelectTurretToBuild(laserBeamer);
    }


    public void PopupTurret()
    {
        tempObject = Instantiate(standartTurret.popup, 
            new Vector3(transform.position.x, transform.position.y, 0), 
            standartTurret.popup.transform.rotation);

    }

    public void PopupLaser()
    {
        tempObject = Instantiate(laserBeamer.popup,
            new Vector3(transform.position.x, transform.position.y, 0),
            laserBeamer.popup.transform.rotation);
    }

    public void PopupMissile()
    {
        tempObject = Instantiate(missileLauncher.popup,
            new Vector3(transform.position.x, transform.position.y, 0),
            missileLauncher.popup.transform.rotation);
    }

    
    public void Deselect()
    {
        Destroy(tempObject);
    }
}
