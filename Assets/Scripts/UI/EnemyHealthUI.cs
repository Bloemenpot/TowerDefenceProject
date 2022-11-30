using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    void Update()
    {
        List<Enemy> enemies = ActorManager.GetEnemies();

        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i])
                continue;

            enemies[i].healthSlider.value = enemies[i].health / 100.0f;
        }
    }
}
