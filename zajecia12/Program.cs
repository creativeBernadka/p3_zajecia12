using System;
using System.Linq.Expressions;

namespace zajecia12
{
    class Program
    {

        static double CalculatePriceOfTicket(object passenger)
        {

            switch (passenger)
            {
                case Child child:
                    Console.WriteLine($"This is child. They have discount: {child.Discount}");
                    break;
                case ElderPerson discountedPensioner when discountedPensioner.NoPayment:
                    Console.WriteLine("This is elder person. They don't need to pay for ticket.");
                    break;
                case ElderPerson _:
                    Console.WriteLine("This is elder person.");
                    break;
                case Pensioner discountedPensioner 
                    when discountedPensioner.EndOfPension > DateTime.Now 
                         && discountedPensioner.NoPayment:
                    Console.WriteLine("This is pensioner whose pension is still active." +
                                      " He doesn't need to pay for ticket");
                    break;
                case Pensioner pensioner when pensioner.NoPayment:
                    Console.WriteLine("This is pensioner who doesn't need to pay for ticket");
                    break;
                case Pensioner _:
                    Console.WriteLine("This is pensioner");
                    break;
                case null:
                    Console.WriteLine("I don't know this type");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
                    
            }
            return 0.0;
        }
        
        static void Main(string[] args)
        {
            var passenger = new UsualPassenger();
            var child = new Child() { Discount = 0.5 };
            var pensioner = new ElderPerson() { NoPayment = true };
            var annuitant1 = new Pensioner() {NoPayment = true, EndOfPension = new DateTime(2020, 1, 18)};
            var annuitant2 = new Pensioner() {NoPayment = true, EndOfPension = new DateTime(2019, 1, 18)};
            var annuitant3 = new Pensioner() {NoPayment = false, EndOfPension = new DateTime(2020, 1, 18)};

            CalculatePriceOfTicket(passenger);
            CalculatePriceOfTicket(child);
            CalculatePriceOfTicket(pensioner);
            CalculatePriceOfTicket(annuitant1);
            CalculatePriceOfTicket(annuitant2);
            CalculatePriceOfTicket(annuitant3);
            CalculatePriceOfTicket("pasazer");
            CalculatePriceOfTicket(null);
            
            var person = new ElderPerson()
            {
                NoID = "1234567890",
                NoPayment = true,
                BirthDate = DateTime.Now.AddYears(-70),
                PhotoAddress = "./images/photos/`1234567890.jpg"
            };

            (string ID, bool discount, DateTime birthdayDate, string photo) = person.getAllData();
            // var (noID, isDiscount, birthday, photograph) = person.getAllData();
            var temp = person.getAllData();
            // Console.WriteLine($"{temp.NoID} {temp.NoPayment}");
            
            var (noID, isDiscount, birthday, photograph) = person;
            var (onlyNoID, photoAddress) = person;
            
            var child1 = new Child()
            {
                BirthDate = DateTime.Now.AddYears(-12),
                Discount = 0.5
            };
            var child2 = new Child()
            {
                BirthDate = DateTime.Now.AddYears(-5),
                Discount = 0.5
            };
            var child3 = new Child()
            {
                BirthDate = DateTime.Now.AddYears(-16),
                Discount = 0.5
            };
            var child4 = new Child()
            {
                BirthDate = DateTime.Now.AddYears(-21),
                Discount = 0.5
            };

            var (discountRate, birthDate , typeOfSchool) = child1;
            var (discountRate2,birthDate2, typeOfSchool2) = child2;
            var (discountRate3,birthDate3, typeOfSchool3) = child3;
            var (discountRate4,birthDate4,  typeOfSchool4) = child4;
            
            Console.WriteLine($"Child's 1 type of school: {typeOfSchool}. Date of birth: {birthDate}");
            Console.WriteLine($"Child's 2 type of school: {typeOfSchool2}. Date of birth: {birthDate2}");
            Console.WriteLine($"Child's 3 type of school: {typeOfSchool3}. Date of birth: {birthDate3}");
            Console.WriteLine($"Child's 4 type of school: {typeOfSchool4}. Date of birth: {birthDate4}");
        }
    }
}