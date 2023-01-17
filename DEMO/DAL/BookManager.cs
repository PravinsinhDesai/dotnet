using BOL;
namespace DAL;

public class BookManager
{

    public static List<Book> GetAllBooks(){
        using(var con=new Context()){

            var b1=from b in con.books select b;
            return b1.ToList<Book>();
        }
    }

    public static bool insertBook(Book book){
         using(var con=new Context()){

            con.books.Add(book);
            con.SaveChanges();
            return true;
        }

    }
    public static bool Deletebook(int id){
         using(var con=new Context()){

            con.books.Remove(con.books.Find(id));
            con.SaveChanges();
            return true;
        }

    }

    public static Book FindById(int id){
         using(var con=new Context()){

            Book bk=con.books.Find(id);
            
            return bk;
        }

    }

    public static void Update(Book book){

        using(var con=new Context()){

            Book bk=con.books.Find(book.Id);
            
            bk.Name=book.Name;
            con.SaveChanges();
        
        }
    }

}
