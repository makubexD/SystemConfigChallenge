//using PremiumCalculator.Common;
//using PremiumCalculator.DTOs;
//using System;
//using System.Linq;
//using System.Collections.Generic;
//using PremiumCalculator.ServicesCore;

//namespace PremiumCalculator.ReadServices
//{
//    public class CalculatorServices
//    {
//        private readonly IStateFactory _stateFactory;
//        private IState _state;
        
//        public CalculatorServices(IStateFactory stateFactory)
//        {
//            _stateFactory = stateFactory;
//        }

//        public PremiumResponseDto GetPremium(DateTime dateOfBirth, string state, int age)
//        {
//            if (ValidateBirthDate(dateOfBirth, age)) return null;
            
//            var states = new List<string> { Constants.States.NY, Constants.States.AL, Constants.States.AK };
//            state = states.Any(a => a == state) ? state : Constants.States.Other;

//            _state = _stateFactory.ResolveByName(state);

//            return _state.GetPremium(dateOfBirth, age);
//        }

//        public bool ValidateBirthDate(DateTime dateOfBirth, int age)
//        {
//            return Utils.GetAge(dateOfBirth) != age;
//        }
//    }
//}
