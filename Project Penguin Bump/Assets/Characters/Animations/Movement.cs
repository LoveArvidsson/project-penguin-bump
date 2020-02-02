﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{



 private Animator _animator;





    // Start is called before the first frame update
    void Start()


    {

_animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

 if (_animator == null) return;

var x = Input.GetAxis("Horizontal");
var y = Input.GetAxis("Vertical");

Move(x,y);


        
    }

private void Move(float x, float y)
{

_animator.SetFloat("VelX", x);
_animator.SetFloat("VelY", y);



    }


}
