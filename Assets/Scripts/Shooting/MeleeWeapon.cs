using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private Animator _animator;
    private float _dmg;
    private float _range;

    private bool _isAttacking = false;
    private bool _isChainAttack = false;

    public Animator Animator => _animator;
    public float Dmg { get => _dmg; set => _dmg = value; }
    public float Range { get => _range; set => _range = value; }

    public bool IsAttacking
    {
        get => _isAttacking;
        set
        {
            _isAttacking = value;
            _animator.SetBool("isAttacking", value);
        }
    }
    public bool IsChainAttack
    {
        get => _isChainAttack;
        set
        {
            _isChainAttack = value;
            _animator.SetBool("isChainAttack", value);
        }
    }

    public void OnAttack1End()
    {
        IsAttacking = false;
    }

    public void OnAttack2End()
    {
        IsAttacking = false;
        IsChainAttack = false;
    }


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
