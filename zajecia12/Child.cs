using System;

namespace zajecia12
{
    public class Child
    {
        public double Discount { get; set; }
        public DateTime BirthDate { get; set; }

        public void Deconstruct(out double discount, out DateTime birthDate, out string school)
        {
            discount = Discount;
            birthDate = BirthDate;
            
            school = "none";
            var age = (int) ((DateTime.Now - BirthDate).Days / 365.2425);
            if ( age >= 6 && age < 14)
            {
                school = "Primary school";
            } else if (age >= 14 && age < 18)
            {
                school = "High school";
            } else if (age >= 18)
            {
                school = "College";
            }
        }
    }
}