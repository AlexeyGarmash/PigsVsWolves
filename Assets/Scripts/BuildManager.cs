using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private bool isFirstBuild = false;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("One more mangaer");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    //void Start()
    //{
    //    turretToBuild = standartTurretPrefab;
    //}

    private TurretBlueprint turretToBuild;
    private TurretBlueprint previosturretToBuild;
    private Node selectedNode;



    public NodeUI nodeUI;
    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool CanHover
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        

        selectedNode = null;
        
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        if (isFirstBuild)
            previosturretToBuild.prefabImage.color = Color.white;
        isFirstBuild = true;
        turretToBuild = turret;
        previosturretToBuild = turretToBuild;
        DeselectNode();
        turretToBuild.prefabImage.color = Color.red;
    }


    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public TurretBlueprint GetTurretToBuildPrevious()
    {
        return previosturretToBuild;
    }

}
