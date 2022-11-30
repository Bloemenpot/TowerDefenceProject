using System.Collections.Generic;
using UnityEngine;

public class ActorManager : Manager
{
    private static Dictionary<int, Actor> actors;
    private static List<Enemy> enemies;

    public ActorManager()
    {
        actors = new Dictionary<int, Actor>();
        enemies = new List<Enemy>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        //base.Update();
    }

    public static void Register(Actor actor)
    {
        int ID = actor.gameObject.GetInstanceID();
        //Debug.Log(ID);
        if (!actors.ContainsKey(ID))
        {
            actors.Add(ID, actor);

            if (actor.GetType() == typeof(Enemy) || actor.GetType().IsSubclassOf(typeof(Enemy)))
            {
                enemies.Add((Enemy)actor);
            }
        }
    }

    public static List<Enemy> GetEnemies()
    {
        enemies.RemoveAll(IsNull);
        return enemies;
    }

    private static bool IsNull(Enemy enemy)
    {
        return enemy;
    }
}