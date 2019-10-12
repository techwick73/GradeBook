using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);

        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Do the Triple As: Arrange, Act & Assert

            // Arrange
            var book1 = GetBook("Book1");
            GetBookSetName(ref book1, "New Name");

            // Act

            // Assert
            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            // Do the Triple As: Arrange, Act & Assert

            // Arrange
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New Name");

            // Act

            // Assert
            Assert.Equal("Book1", book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            // Do the Triple As: Arrange, Act & Assert

            // Arrange
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");

            // Act

            // Assert
            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Do the Triple As: Arrange, Act & Assert

            // Arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");


            // Act


            // Assert
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);

        }

        [Fact]
        public void TwoVariablesReferenceSameObject()
        {
            // Do the Triple As: Arrange, Act & Assert

            // Arrange
            var book1 = GetBook("Book1");
            var book2 = book1;

            // Act


            // Assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
