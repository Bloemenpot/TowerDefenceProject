using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint minigunTurret;
    public TurretBlueprint missileLauncher;
    public GameObject player;
    public Text SelectedTurretUI;



    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
        player.SetActive(false);
        SelectedTurretUI.text = "Standard Turret";
        SelectedTurretUI.color = new Color32(67, 0, 0, 255);
        SelectedTurretUI.fontSize = 19;
    }
    public void SelectMinigunTurret()
    {
        buildManager.SelectTurretToBuild(minigunTurret);
        player.SetActive(false);
        SelectedTurretUI.text = "Minigun Turret";
        SelectedTurretUI.color = new Color32(0, 202, 15, 255);
        SelectedTurretUI.fontSize = 19;
    }
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
        player.SetActive(false);
        SelectedTurretUI.text = "Missile Launcher";
        SelectedTurretUI.color = new Color32(0, 244, 255, 255);
        SelectedTurretUI.fontSize = 19;
    }
    public void SelectGrenadeThrowing()
    {
        buildManager.SelectTurretToBuild(null);
        player.SetActive(true);
        SelectedTurretUI.text = "Nuke";
        SelectedTurretUI.color = new Color32(255, 0, 20, 255);
        SelectedTurretUI.fontSize = 36;
    }
}
