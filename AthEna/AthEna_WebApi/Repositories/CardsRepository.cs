﻿using AthEna_WebApi.Models;
using AthEna_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AthEna_WebApi.Repositories
{
    public class CardsRepository : InitialRepository
    {
        public List<CardOutgoingViewModel> GetAllCards()
        {
            try
            {
                var cardsList = db.Cards.Select(s=> new CardOutgoingViewModel {
                    CardId = s.CardId,
                    ChargeExpiresOn = s.ChargeExpiresOn,
                    ContactId = s.ContactId,
                    lastRecharedOn = s.LastRechargedOn,
                    RegisteredOn = s.RegisteredOn,                
                }).ToList();
                return cardsList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CardOutgoingViewModel GetCard(Guid cardId)
        {
            try
            {
                var cardRequested = db.Cards.Where(w=>w.CardId == cardId).Select(s => new CardOutgoingViewModel
                {
                    CardId = s.CardId,
                    ChargeExpiresOn = s.ChargeExpiresOn,
                    ContactId = s.ContactId,
                    lastRecharedOn = s.LastRechargedOn,
                    RegisteredOn = s.RegisteredOn,
                }).FirstOrDefault();
                return cardRequested;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Card CreateNewCard(Card newCardToAdd)
        {
            try
            {
                var asdf = new Card()
                {
                    CardId = Guid.NewGuid()
                };
                return asdf;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public dynamic GetContactsWithCards()
        {
            try
            {
                var cons = db.Contacts.ToList();
                var cards = db.Cards.ToList();

                var joinedList = cons.Join(cards, a => a.ContactId, b => b.ContactId, (a, b) => new { a.ContactId, a.FirstName, a.LastName, b.CardId, b.ChargeExpiresOn }).ToList();
                return joinedList;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }



    }
}
