﻿namespace PlayersAndMonsters.Models.Cards
{
    using System;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCardNameException);
                }

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(
                    value,
                    ExceptionMessages.InvalidCardDamagePointsException);

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                Validator.ThrowIfIntegerIsBelowZero(
                    value,
                    ExceptionMessages.InvalidCardHPException);

                this.healthPoints = value;
            }
        }
    }
}
