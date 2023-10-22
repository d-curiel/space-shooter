using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupedShootingHandler : MonoBehaviour
{
    [SerializeField]
    ShootingComponent[] shootingComponents;

    private void HandleShoot(int shooter)
    {
        shootingComponents[shooter]?.Shoot();
    }
}
