using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Speed
{
    public float run;
    public float walk;
}

public class PlayerMotor : MonoBehaviour
{
    public Speed speed;
    private int _lookAt = 2;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //faz a movimentação do jogador caso a tecla esteja precionada
    void Move()
    {
        //pega os inputs de horizontal e vertical predefinidos pela unity retornando um valor positivo ou negativo
        float _movX = Input.GetAxisRaw("Horizontal");
        float _movY = Input.GetAxisRaw("Vertical");

        //altera a velocidade do jogador caso ele esteja precionando o shift esquerdo
        float _speed = (Input.GetKey(KeyCode.LeftShift)) ? speed.run : speed.walk;

        Vector3 velocity = new Vector3(_movX, _movY, 0) * Time.deltaTime * _speed;

        //seta a ação do jogador como andando caso uma tecla de movimentação esteja sendo precionada
        animator.SetBool("Walking", _movX != 0 || _movY != 0);
        animator.SetBool("transform", _speed > speed.walk);

        /*realiza a movimentação do jogador dependendo da direção olhada e da velocidade
        0 = Norte, 1 = Oeste, 2 = Sul, 3 = Leste*/
        if (velocity.y > 0) _lookAt = 0;
        else if (velocity.x > 0) _lookAt = 3;
        else if (velocity.x < 0) _lookAt = 1;
        else if (velocity.y < 0) _lookAt = 2;

        animator.SetInteger("lookAt", _lookAt);

        transform.position += velocity;
    }
}
