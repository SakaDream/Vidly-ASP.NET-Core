using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO MembershipTypes(Id, Name, SignUpFee, DurationInMonths, DiscountRate) " +
                "VALUES " +
                "(1, 'Pay as You Go', 0, 0, 0), " +
                "(2, 'Monthly', 30, 1, 10), " +
                "(3, 'Quarterly', 90, 3, 15), " +
                "(4, 'Annual', 300, 12, 20)");

            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) " +
                                 "VALUES " +
                                 "(1, 'Action'), " +
                                 "(2, 'Thriller'), " +
                                 "(3, 'Family'), " +
                                 "(4, 'Romance'), " +
                                 "(5, 'Comedy')");

            migrationBuilder.Sql(
                "INSERT INTO Customers (Name, Birthday, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('John Smith', '1994/04/20', 0, 1)");
            migrationBuilder.Sql(
                "INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Mary Williams', 1, 2)");

            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                                 "VALUES " +
                                 "('Hangover', 5, '2009/06/02', '2017/11/30', 5), " +
                                 "('Die Hard', 1, '1988/07/12', '2017/11/30', 3), " +
                                 "('The Terminator', 1, '1984/10/26', '2017/11/30', 8), " +
                                 "('Toy Story', 3, '1995/11/19', '2017/11/30', 10), " +
                                 "('Titanic', 4, '1997/11/18', '2017/11/30', 21)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
