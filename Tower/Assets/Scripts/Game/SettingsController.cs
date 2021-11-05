using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    // Common
    public const string TrashContainerObjectName = "TrashContainer";


    // Game
    public const int StartCoinsVale = 100;
    public const int CountGamersLifes = 3;



    // TowerPlace
    public static Color EmptyTowerPlaceColor = new Color(0f, 0.7f, 0f, 0.1f);
    public static Color SelectionTowerPlaceColor = new Color(0.1f, 0.8f, 0.1f, 0.5f);
    public static Color DeleteTowerPlaceColor = new Color(0.9f, 0f, 0f, 0.5f);


    // 1) Tower
    public const int TowerBuildingCost = 50;


    // 2). Tower Bullet
    public const float TowerBulletSpeed = 0.4f;
    public const float TowerBulletTimeLife = 1f;
    public const float TowerBulletDamage = 25f;





    // 3). Enemy
    public const int EnemyDeathCost = 20;
    public const int EnemyMaxLife = 120;
    public static float EnemyMovingSpeed = 1f;
    public const string EnemyWayPointsGroup = "WayPoints";
    public const float EnemyDieEffectIntervalDissapear = 0.5f;
    public static float SpawnEnemyItemsInterval = 2f;
 




}

