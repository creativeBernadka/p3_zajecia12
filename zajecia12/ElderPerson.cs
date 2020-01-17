using System;
using System.Diagnostics.CodeAnalysis;

namespace zajecia12
{
    public class ElderPerson
    {
        
        public string NoID { get; set; }
        public bool NoPayment { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoAddress { get; set; }

        public (string, bool, DateTime, string) getAllData()
        {
            return (NoID, NoPayment, BirthDate, PhotoAddress);
        }

        public void Deconstruct(out string noID, out bool noPayment, out DateTime birthDate, out string photoAddress)
        {
            noID = NoID;
            noPayment = NoPayment;
            birthDate = BirthDate;
            photoAddress = PhotoAddress;
        }
        
        public void Deconstruct(out string noID, out string photoAddress)
        {
            noID = NoID;
            photoAddress = PhotoAddress;
        }
    }
}