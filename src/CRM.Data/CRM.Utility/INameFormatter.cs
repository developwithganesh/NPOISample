using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Utility
{
  public interface INameFormatter
  {
    string Name { get; set; }
    int AllowedMaxLength { get; set; }
    string Format(string value);
  }

  public class NameFormatter : INameFormatter
  {
    public NameFormatter(string name, int allowedMaxLength = 20)
    {
      this.AllowedMaxLength= allowedMaxLength;
      Name = name;

    }
    private string name;

    public string Name
    {
      get { return name; }
      set
      {
        if (name != value)
        {
          name = Format(value);
        }
      }
    }

    public string Format(string value)
    {
      var escapedSheetName = value
                                    .Replace("/", "-")
                                    .Replace("\\", " ")
                                    .Replace("?", string.Empty)
                                    .Replace("*", string.Empty)
                                    .Replace("[", string.Empty)
                                    .Replace("]", string.Empty)
                                    .Replace(":", string.Empty);

      if (escapedSheetName.Length > AllowedMaxLength && AllowedMaxLength > 0)
        escapedSheetName = escapedSheetName.Substring(0, AllowedMaxLength);

      return escapedSheetName;
    }

    private int allowedMaxLength;

    public int AllowedMaxLength
    {
      get { return allowedMaxLength; }
      set { allowedMaxLength = value; }
    }
    
  }
}
