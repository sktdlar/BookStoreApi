using System;
using System.Collections.Generic;

namespace BookStoreApiASP.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int PagesCount { get; set; }

    public decimal Price { get; set; }
}
