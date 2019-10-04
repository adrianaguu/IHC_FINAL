#pragma strict

var bulletDamage = 100;

function OnCollisionEnter (info : Collision)

    {
        info.transform.SendMessage("ApplyDamage", bulletDamage, SendMessageOptions.DontRequireReceiver);
    }