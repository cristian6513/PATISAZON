using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATISAZON.Models
{
    public class ShoppingCart
    {
        private Platillos food;
        private int cantidad;
        public ShoppingCart() { }
        public ShoppingCart(Platillos food, int cant)
        {
            Food = food;
            Cantidad = cant;
        }

        public Platillos Food { get => food; set => food = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}