using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Events
{

}


public class GameIsStarted
{

}


public class EnemyDeathEventData
{
    public EnemyType Enemy;
    public int EnemyDeathCost; 
}


public class TowerBuildingEventData
{
    public TowerType TowerTypeData;
    public int TowerBuildingCost;
}


public class EnemyWasMovedToFinish
{
    public EnemyType Enemy;
}

















// типы башен
public enum TowerType
{
    Duck,
    ForcedDuck
}


// типы врагов
public enum EnemyType
{
    EnemyCat,
    EnemyPenguine
}