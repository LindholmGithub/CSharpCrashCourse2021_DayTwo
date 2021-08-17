﻿using System;
using CrashCourse2021ExercisesDayTwo.Models;
using Xunit;
using Xunit.Sdk;

namespace CrashCourse2021ExercisesDayTwo.Services
{
    //This is the only Class where you should change code!! :)
    public class CreditService
    {
        private Credit credit;
        private Constants constants;

        public CreditService()
        {
            credit = new Credit { Value = 0, MaxAllowed = 10000d};
        }

        internal double CurrentCreditValue()
        {
            return credit.Value;
        }

        internal void AddCredit(double valueToAdd)
        {
            if (valueToAdd < 0)
            {
                throw new ArgumentException(Constants.CreditToAddMustBeZeroOrMoreException);
            }
            if (credit.Value + valueToAdd > CurrentMaxAllowedValue())
            {
                throw new ArgumentException(Constants.CreditCannotExceedMaxValueException);
            }
            else
            {
                credit.Value += valueToAdd;
            }
        }

        internal void RemoveCredit(double valueToRemove)
        {
            if (valueToRemove < 0)
            {
                throw new ArgumentException(Constants.CreditToRemoveMustBeZeroOrMoreException);
            }
            if (credit.Value - valueToRemove < 0)
            {
                throw new ArgumentException(Constants.CreditCannotBeLessThenZeroException);
            }
            credit.Value -= valueToRemove;
        }

        internal double CurrentMaxAllowedValue()
        {
            return credit.MaxAllowed;
        }

        internal void SetMaxAllowedValue(double maxValue)
        {
            if (maxValue > 1000000000d)
            {
                throw new ArgumentException(Constants.CreditMaxValueCannotBeAboveABillionException);
            }

            if (maxValue < 0)
            {
                throw new ArgumentException(Constants.CreditMaxValueMustBeAboveZeroException);
            }
            else
            {
                credit.MaxAllowed = maxValue;
            }
        }
    }
}
