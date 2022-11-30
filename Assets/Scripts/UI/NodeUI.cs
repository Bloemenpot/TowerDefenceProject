using UnityEngine;
using UnityEngine.UI;

public class NodeUI : Actor
{
    public GameObject ui;
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Remove()
    {
        target.RemoveTurret();
        BuildManager.instance.DeselectNode();
    }
}
