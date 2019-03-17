using UnityEngine;

public class DonkeyBehaviour : MonoBehaviour {

    [SerializeField] private Animator _animator;
    private float _nextEatTime;
    private float _timer;
    
    
    // Use this for initialization
	private void Start () {
        //_animator = GetComponent<Animator>();
        _nextEatTime = Random.Range(0f, 10f);
        _timer = 0f;
	}
	
	// Update is called once per frame
	private void Update () {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Eat"))
        {
            _animator.SetBool("Eat", false);
            _nextEatTime = Random.Range(20f, 60f);
            _timer = 0f;
        }
        else
        {
            _timer += Time.fixedDeltaTime;
            if(_timer > _nextEatTime)
            {
                _animator.SetBool("Eat", true);
            }
        }

	}
}
