public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) 
        => (IsNewYork: phoneNumber.Split("-")[0] == "212",
            IsFake: phoneNumber.Split("-")[1] == "555",
            LocalNumber: phoneNumber.Split("-")[2]);                         

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
