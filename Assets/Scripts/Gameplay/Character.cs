using DG.Tweening;
using UnityEngine;
using Zenject;
using System;

public class Character : MonoBehaviour
{
    private Settings settings;
    private Camera mainCamera;
    private CircleCollider2D circleCollider;
    private ProgressManager progressManager;
    private Vector3 savedPosition;
    private float distDelta;

    [Inject]
    public void Construct(Settings settings, ProgressManager progressManager)
    {
        this.settings = settings;
        this.progressManager = progressManager;
        circleCollider = GetComponent<CircleCollider2D>();
        mainCamera = Camera.main;
        savedPosition = transform.position;
    }

    void Update()
    {
        distDelta = (transform.position - savedPosition).magnitude;
        if (distDelta > 0)
        {
            savedPosition = transform.position;
            progressManager.Distance += distDelta;
            distDelta = 0;
        }
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                OnClick(touch.position);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnClick(Input.mousePosition);
        }
    }

    private void OnClick(Vector3 position)
    {
        position = mainCamera.ScreenToWorldPoint(position);
        transform.DOKill();
        if (!circleCollider.OverlapPoint(position))
        {
            var time = (transform.position - position).magnitude / settings.MaxSpeed;
            transform.DOMove(new Vector3(position.x, position.y, 0), time);
        }
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        progressManager.Score++;
        Destroy(collision.gameObject);
    }

    [Serializable]
    public class Settings
    {
        public float MaxSpeed;
    }
}
