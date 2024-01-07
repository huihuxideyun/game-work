using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   public float moveSpeed = 5f;
   public float rotationSpeed = 180f;
   private Animator _animator;

   private void Start()
   {
      _animator = GetComponent<Animator>();
      if (PlayfabManager.Instance != null)
      {
         PlayfabManager.Instance.SetPlayer(this.transform);
         DontDestroyOnLoad(this.gameObject); 
      }
   }

   private void Update()
   {
      // 获取键盘输入
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      // 计算移动方向
      Vector3 movement = new Vector3(-horizontalInput, 0f, -verticalInput).normalized;

      // 如果有输入，进行移动和旋转
      if (movement.magnitude >= 0.1f)
      {
         _animator.SetBool("isrun",true);
         // 计算目标角度
         float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
         float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
         
         // 应用旋转
         transform.rotation = Quaternion.Euler(0f, angle, 0f);

         // 计算移动方向并进行移动
         Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
         transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
      }
      else
      {
         _animator.SetBool("isrun",false);
      }
   }
}




