namespace UI
{
    public class Dalay : View
    {
        private void OnEnable()
        {
            EnableAction(_spawner.ChangeDelaySpawn);
        }

        private void OnDisable()
        {
            DisableAction(_spawner.ChangeDelaySpawn);
        }
    }
}
