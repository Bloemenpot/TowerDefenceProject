using UnityEngine;
using UnityEngine.EventSystems;
using Managers;

public class Node : Actor
{
    public GameObject turretMenu;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Color cantBuildColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    protected override void Start()
    {
        base.Start();

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Pause();
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (!GameManager.isPaused)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (turret != null)
            {
                buildManager.SelectNode(this);
                return;
            }
            if (!buildManager.CanBuild)
                return;

            BuildTurret(buildManager.GetTurretToBuild());
        }
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        //buildManager.BuildTurretOn(this);

        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Niet genoeg geld");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        Debug.Log("Turret is gebouwd. Je hebt nog " + PlayerStats.Money + " coins over.");
    }

    public void RemoveTurret()
    {
        Destroy(turret);
        turretBlueprint = null;
    }
    
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Niet genoeg geld voor een upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Removing Old turret
        Destroy(turret);

        //Build the upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        isUpgraded = true;
        Debug.Log("Turret is geupgrade. Je hebt nog " + PlayerStats.Money + " coins over.");
    }

    void OnMouseEnter()
    {
        if (!GameManager.isPaused)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!buildManager.CanBuild)
                return;



            if (buildManager.HasMoney)
            {
                if (turret != null)
                {
                    rend.material.color = cantBuildColor;
                }
                else
                {
                    rend.material.color = hoverColor;
                }
            }
            else
            {
                if (turret != null)
                {
                    rend.material.color = cantBuildColor;
                }
                else
                {
                    rend.material.color = notEnoughMoneyColor;
                }
            }
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
