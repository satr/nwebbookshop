using System.Collections.Generic;
using PATestApp.DAL;
using PATestApp.Entities;

namespace PATestApp.BL{
    public class LibraryBusinessProvider: ILibraryBusinessProvider{
        public List<Book> GetBooks(){
            var dataProvider = DataProviderFactory.GetLibraryDataProvider();
            var books = dataProvider.GetBooks();
            ApplyDiscount(books);
            return books;
        }

        private static void ApplyDiscount(IEnumerable<Book> books){
            foreach (var book in books){
                DiscountManager.GetStrategyFor(book).Apply(book);
            }
        }
    }

    internal class DiscountManager{
        public static AbstractDiscount GetStrategyFor(Book book){
            if(book.PublishedYear > 5)
                return new MaxDiscount();
            if (book.PublishedYear > 3)
                return new MediumYearDiscount();
            if (book.PublishedYear > 1)
                return new MinYearDiscount();
            return new NullDiscount();
        }
    }

    internal class MinYearDiscount : AbstractDiscount{
        public MinYearDiscount() : base(10){
        }
    }

    internal class MaxDiscount : AbstractDiscount{
        public MaxDiscount() : base(50){
        }
    }

    internal class MediumYearDiscount : AbstractDiscount{
        public MediumYearDiscount() : base(30){
        }
    }

    internal class NullDiscount: AbstractDiscount{
        public NullDiscount() : base(0){
        }
    }

    internal abstract class AbstractDiscount{
        public decimal Discount { get; set; }

        protected AbstractDiscount(decimal discount){
            Discount = discount;
        }

        public void Apply(Book book){
            book.Price -= Discount/100*book.Price;
        }
    }
}