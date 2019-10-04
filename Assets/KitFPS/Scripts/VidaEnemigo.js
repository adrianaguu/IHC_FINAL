#pragma strict

var Health = 100;

function ApplyDamage (TheDamage : int)

{
    Health -= TheDamage;

    if (Health <= 0)
    {
        Dead();
    }
}

function Dead()

{
    Destroy (gameObject);
}