using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PrallaxBackground : MonoBehaviour
{
    [SerializeField] [Range(0, 1f)] private float _speedMultiplier = 0.1f;
    [SerializeField] private List<Sprite> _sprites;

    private Animator _animator;
    private SpriteRenderer[] _backGroundObjects;
    private Transform _transform => gameObject.transform;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        SpeedChange();
        GetBackgroundObjectList();
        SelectSpriteToBackground();
    }

    private void SpeedChange()
    {
        _animator.speed = 1 * _speedMultiplier;
    }

    private void SelectSpriteToBackground()
    {
        var currentSprite = Random.Range(0, _sprites.Count);
        for(int i = 0; i < _backGroundObjects.Length; i++)
            _backGroundObjects[i].sprite = _sprites[currentSprite];    
    }


    private void GetBackgroundObjectList()
    {
        var count = _transform.childCount;
        _backGroundObjects = new SpriteRenderer[count];

        for(int i = 0; i < count; i++)
        {
            if(_transform.GetChild(i).TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
                _backGroundObjects[i] = spriteRenderer;
        }
    }
}