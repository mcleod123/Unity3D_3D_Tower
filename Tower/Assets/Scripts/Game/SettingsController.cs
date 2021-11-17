using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    // Общее
    public const string TrashContainerObjectName = "TrashContainer";


    // Игра
    public const int StartCoinsValeStartValue = 100;
    public const int CountGamersLifesStartValue = 3;
    public static int StartCoinsVale = StartCoinsValeStartValue;
    public static int CountGamersLifes = CountGamersLifesStartValue;



    // Места под башню
    public static Color EmptyTowerPlaceColor = new Color(0f, 0.7f, 0f, 0.1f);
    public static Color SelectionTowerPlaceColor = new Color(0.1f, 0.8f, 0.1f, 0.5f);
    public static Color DeleteTowerPlaceColor = new Color(0.9f, 0f, 0f, 0.5f);


    // Башня
    public const int TowerBuildingCost = 50;


    // Пули башни
    public const float TowerBulletSpeed = 0.4f;
    public const float TowerBulletTimeLife = 1f;
    public const float TowerBulletDamage = 25f;





    // Враг
    public const float EnemyMovingSpeedStartValue = 1f;
    public const float SpawnEnemyItemsIntervalStartValue = 2f;
    public const int EnemyDeathCost = 20;
    public const int EnemyMaxLife = 120;
    public static float EnemyMovingSpeed = EnemyMovingSpeedStartValue;
    public const string EnemyWayPointsGroup = "WayPoints";
    public const float EnemyDieEffectIntervalDissapear = 0.5f;
    public static float SpawnEnemyItemsInterval = SpawnEnemyItemsIntervalStartValue;


    // Враг металлический пингвин
    public const int EnemyPenguineDeathCost = 50;
    public const float PenguineSpeed = 0.3f;
    public const float EnemyPenguineMaxLife = 500f;
    public const float EnemyPenguineSpawnTime = 25f;
    public const float EnemyPenguineItemsInterval = 25f;


    // Строковые значения
    public const string PauseButtonTextOnPause = "В бой!";
    public const string PauseButtonTextOnPlay = "Пауза";


}

