using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
   [SerializeField] private UIInventoryPage invetoryUI;
   public int inventorySize = 10;

   private void Start()
   {
      invetoryUI.InitilizeInventoryUI(inventorySize);
   }

   public void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         if (invetoryUI.isActiveAndEnabled == false)
         {
            invetoryUI.Show();
         }
         else
         {
            invetoryUI.Hide();
         }
      }
   }
}
