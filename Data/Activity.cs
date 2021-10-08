namespace IdentityFarmActivities.Data
{
    public class Activity
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public bool Complete { get; set; }
        public string Owner { get; set; }
    }
}
