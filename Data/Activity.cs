namespace IdentityFarmActivities.Data
{
    /// <summary>
    /// Create the model. This class is used 
    /// to represent the activities,which will be stored in a database
    /// using EF Core
    /// </summary>
    public class Activity
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public bool Complete { get; set; }
        public string Owner { get; set; }
    }
}
