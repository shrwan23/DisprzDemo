using System.ComponentModel;

namespace demo.model.Enums
{
    public enum Department
    {

        [Description("Admin")]
        Admin,

        [Description("Sales")]
        Sales,

        [Description("Engineering")]
        Engineering,

        [Description("Finance")]
        Finance,

        [Description("Support")]
        Support,

        [Description("Marketing")]
        Marketing,
    }
}