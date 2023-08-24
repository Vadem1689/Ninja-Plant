using System;
using Unity.VisualScripting;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] private SpawnPlant _spawnPlant;
    [SerializeField] private Merger _merger;

    private bool _isUsingComputer = false;

    private SpawnPoint _selectedSpawnPoint;
    private BoxCollider _collider;
    private Vector3 _newPosition;
    private RaycastHit _hit;
    private int _countMerge = 0;
    private bool _isTaken = false;
    private Plant _plant;


    public int CountMerge => _countMerge;
    public bool IsTaken => _isTaken;
    public static Action OnallAd;

    private void Start()
    {
        IdentifyDevicecomputer();
    }

    private void Update()
    {
        MakeGrabber();
    }

    private void IdentifyDevicecomputer()
    {
        if (true)
        {
            _isUsingComputer = true;
        }
        else
        {
            _isUsingComputer = false;
        }
    }

    private void MakeGrabber()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_selectedSpawnPoint == null)
            {
                _hit = CastRay();

                if (_hit.collider != null && _hit.collider.TryGetComponent(out SpawnPoint spawnPoint))
                {
                    _selectedSpawnPoint = spawnPoint;
                    _collider = _selectedSpawnPoint.Plant.gameObject.GetComponent<BoxCollider>();
                    return;
                }
            }
            else
            {
                _merger.TryMerge(_selectedSpawnPoint.Plant, _collider);
            }
        }

        if (_selectedSpawnPoint != null)
        {
            if (Input.mousePosition != null)
            {
                MovingSelectedObject();
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Ended)
                {
                    _merger.TryMerge(_selectedSpawnPoint.Plant, _collider);
                    PutPlant(_selectedSpawnPoint);
                }
            }
        }
    }


    private void MovingSelectedObject()
    {
        if (_selectedSpawnPoint.Plant != null)
        {
            _selectedSpawnPoint.Plant.StopSpawn();
        }

        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.WorldToScreenPoint(_selectedSpawnPoint.Plant.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        _selectedSpawnPoint.Plant.transform.position = new Vector3(worldPosition.x, 3.5f, worldPosition.z);
        //_selectedObject.TakePlant();

        _plant = _selectedSpawnPoint.Plant;
        _selectedSpawnPoint.DeletePlant();
        _collider.enabled = false;

        _isTaken = true;
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNer = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNer);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        Debug.DrawRay(worldMousePosNear, (worldMousePosFar - worldMousePosNear) * 100, Color.red);

        return hit;
    }


    public void PutPlant(SpawnPoint spawnPoint)
    {
        spawnPoint.SetPlant(_plant);
        spawnPoint.Plant.StartSpawn();

        spawnPoint.Plant.transform.position = spawnPoint.transform.position;

        //_selectedObject.Release();
        _collider.enabled = true;
        _selectedSpawnPoint = null;
        _isTaken = false;
    }
}