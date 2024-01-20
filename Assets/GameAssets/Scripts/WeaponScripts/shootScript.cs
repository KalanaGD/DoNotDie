using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    [SerializeField] private Transform _firingPos;
    [SerializeField] private GameObject _bulletPrefab;
    private GameObject _firedBullet;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //instantiate bullet
            _firedBullet = Instantiate(_bulletPrefab, _firingPos.position, Quaternion.identity);
        }
    }
}
