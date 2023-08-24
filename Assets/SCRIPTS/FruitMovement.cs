using DG.Tweening;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Fruit))]
[RequireComponent(typeof(BoxCollider))]
public class FruitMovement : MonoBehaviour
{
    [SerializeField] private float _radiusTarget;

    private Basket _basket;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Fruit _fruit;
    private bool _isCut = false;
    private BoxCollider _collider;
    private float _jumpForce = 3f;
    private int _numJumps = 2;
    private float _duration = 1.2f;

    public bool IsCut => _isCut;
    public static Action<Fruit> OnCut;

    private void Start()
    {
        
        //_rb = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
        //_fruit = GetComponent<Fruit>();
    }
    public void SetTargetMovement(Basket basket)
    {
        _basket = basket;
    }

    public void Jump()
    {
        if (!_isCut)
        {
            _rb.DOJump(_basket.transform.position + new Vector3(Random.Range(-_radiusTarget, _radiusTarget), 0f,
                    Random.Range(-_radiusTarget, _radiusTarget)),
                _jumpForce, _numJumps, _duration, false).OnComplete(() =>
            {
                _collider.enabled = true;
                _rb.useGravity = true;
            });
            print(_rb.isKinematic);
            _rb.isKinematic = false;
            gameObject.transform.parent = null;

            OnCut?.Invoke(_fruit);
            _isCut = true;
        }
    }
}
