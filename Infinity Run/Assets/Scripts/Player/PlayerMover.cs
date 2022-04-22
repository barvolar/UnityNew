using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeigh;
    [SerializeField] private float _minHeigh;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        else
            transform.rotation = Quaternion.Euler(_targetPosition.x, _targetPosition.y, -90f);
    }
    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeigh)
        {
            transform.rotation = Quaternion.Euler(_targetPosition.x, _targetPosition.y, -72f);
            SetNextPosition(_stepSize);
        }
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeigh)
        {
            transform.rotation = Quaternion.Euler(_targetPosition.x, _targetPosition.y, -108f);
            SetNextPosition(-_stepSize);
        }
    }

}
