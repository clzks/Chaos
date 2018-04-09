using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Target;
    public Transform BulletTransform;

    private void Awake()
    {
        BulletTransform = GameObject.Find("Player/ToonSoldier_demo/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/WeaponContainer/BulletSpot").transform;
    }

    private void Update()
    {
        //this.transform.position = GameObject.Find("Player/ToonSoldier_demo/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/WeaponContainer/BulletSpot").transform.position;
        
    }
}
