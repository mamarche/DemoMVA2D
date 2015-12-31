using UnityEngine;
using System.Collections;

public class PersonaggioScript : MonoBehaviour {

    public float velocita = 5f;
    public Transform posizionePiedi;
    public LayerMask layerTerreno;
    public float forzaSalto = 5f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Transform _transform;

    private float direzione;
    private bool giratoDestra = true;
    [SerializeField]
    private bool aTerra = false;
    private bool doppioSalto = true;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transform = transform;
    }
    	
	void Update ()
    {
        direzione = Input.GetAxis("Horizontal");

        aTerra = Physics2D.OverlapCircle(new Vector2(posizionePiedi.position.x, posizionePiedi.position.y), 0.1f, layerTerreno);

        _animator.SetBool("aTerra", aTerra);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (aTerra)
            {
                Salta();
                doppioSalto = true;
            }
            else if (doppioSalto)
            {
                Salta();
            }
        }
	}

    void FixedUpdate()
    {
        if (direzione != 0f)
        {
            _rigidbody.velocity = new Vector2(direzione * velocita, _rigidbody.velocity.y);
            _animator.SetFloat("velocita_orizzontale", Mathf.Abs(_rigidbody.velocity.x));
        }
        else
        {
            _animator.SetFloat("velocita_orizzontale", 0f);
        }
        _animator.SetFloat("velocita_verticale", _rigidbody.velocity.y);


        if ((giratoDestra && _rigidbody.velocity.x < -0.1f) || (!giratoDestra && _rigidbody.velocity.x > 0.1f))
            Gira();
    }

    void Gira()
    {
        giratoDestra = !giratoDestra;
        _transform.localScale = new Vector3(_transform.localScale.x * -1, _transform.localScale.y, _transform.localScale.z);
        
    }

    void Salta()
    {
        _rigidbody.AddForce(Vector2.up * forzaSalto, ForceMode2D.Impulse);
        doppioSalto = false;
    }
}
