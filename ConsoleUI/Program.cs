using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarManager carManager = new CarManager(new EfCarDal());
            //UpdateMethod(carManager);

            // CarDetailMethod(carManager);

           // UserAddMethod();

            //CustomerDetailsMethod();,

            //  DateTime time = DateTime.Parse("03-05-2020");

            //RentalAddMethod();

        }

        private static void RentalAddMethod()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CarId = 2, CustomerId = 1, RentDate = DateTime.Parse("04-05-2020"), ReturnDate = DateTime.Parse("05-05-2020") };
            var result = rentalManager.Add(rental);
            if (result.success == true)
            {
                Console.WriteLine(rental.Id + " --- " + rental.CustomerId + " --- " + rental.RentDate + " --- " +
                    rental.ReturnDate);

                Console.WriteLine(result.message);
            }
            else
                Console.WriteLine(result.message);
        }

        private static void CustomerDetailsMethod()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetails();

            if (result.success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.Id + " --- " + customer.FirstName + " --- " + customer.LastName + " --- " +
                        customer.Email);
                }
                Console.WriteLine(result.message);
            }
            else
                Console.WriteLine(result.message);
        }

        private static void UserAddMethod()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { Id = 4, FirstName = "Korhan", LastName = "Temiz", Email = "korhantmz@hotmail.com", Password_ = "temizzz" };
            var result = userManager.Add(user);

            if (result.success == true)
            {
                Console.WriteLine(result.message);
            }
            else
                Console.WriteLine(result.message);
        }

        private static void CarDetailMethod(CarManager carManager)
        {
            var result = carManager.GetCarDetail();

            if (result.success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " --- " + car.CarName + " --- " + car.ColorName + " --- " + car.DailyPrice);
                }
                Console.WriteLine(result.message);
            }
            else
            {
                Console.WriteLine(result.message);
            }
        }

        private static void UpdateMethod(CarManager carManager)
        {
            var result2 = carManager.GetById(1);

            if (result2.success == true)
            {
                var gelen = result2.Data;
                gelen.CarName = "Alperen";
                var result3 = carManager.Update(gelen);
                Console.WriteLine(result3.message);
            }
            else
                Console.WriteLine(result2.message);
        }
    }
}
