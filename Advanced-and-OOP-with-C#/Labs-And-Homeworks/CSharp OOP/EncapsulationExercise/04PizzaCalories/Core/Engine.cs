﻿using System;

using _04PizzaCalories.Models;

namespace _04PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                string[] doughInfo = Console.ReadLine().Split();

                Dough dough = CreateDough(doughInfo);

                Pizza pizza = CreatePizza(pizzaInfo, dough);

                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = input.Split();

                    Topping topping = CreateTopping(toppingInfo);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }        
        }

        private Pizza CreatePizza(string[] pizzaInfo, Dough dough)
        {
            string pizzaName = pizzaInfo[1];

            Pizza pizza = new Pizza(pizzaName, dough);

            return pizza;
        }

        private Topping CreateTopping(string[] toppingInformation)
        {
            string toppingType = toppingInformation[1];
            double toppingWeight = double.Parse(toppingInformation[2]);

            Topping topping = new Topping(toppingType, toppingWeight);

            return topping;
        }

        private Dough CreateDough(string[] doughInformation)
        {
            string flourType = doughInformation[1];
            string bakingTechnique = doughInformation[2];
            double flourWeight = double.Parse(doughInformation[3]);

            Dough dough = new Dough(flourType, bakingTechnique, flourWeight);

            return dough;
        }
    }
}
