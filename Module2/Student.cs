using System;
using System.Collections.Generic;
using System.Text;

namespace Module2
{
  //public class Student
  //{
  //  public string FirstName { get; set; }
  //  public string LastName { get; set; }
  //  public string[] Clubs { get; set; }
  //}

  //Exercise 5 
  //public class Student
  //{
  //  public string studentAlias { get; set; }
  //  public int age { get; set; }
  //  public int enrollmentYear { get; set; }
  //  public int projectedGraduationYear { get; set; }

  //// Task IV Observe How Partitions Are Accessed in a Cross-Partition Query
  public class Student
  {
    public string studentAlias { get; set; }
    public int age { get; set; }
    public int enrollmentYear { get; set; }
    public int projectedGraduationYear { get; set; }

    public FinancialInfo financialData { get; set; }

    public class FinancialInfo
    {
      public double tuitionBalance { get; set; }
    }
  }
}
