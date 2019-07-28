using UnityEngine;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour {
    public GameObject ui;

    private Node target;

    public Text costUpgradeText;
    public Text sellAmountText;

    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        

        if (!target.isUpgraded)
        {
            costUpgradeText.text = "$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            costUpgradeText.text = "DONE!";
            upgradeButton.interactable = false;
        }

        sellAmountText.text = "$" + target.turretBlueprint.GetSellAmount().ToString();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
        
    }


    public void Upgrade()
    {
        target.turretBlueprint.prefabImage.color = Color.white;
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.turretBlueprint.prefabImage.color = Color.white;
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
