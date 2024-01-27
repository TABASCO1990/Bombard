namespace UI
{
    public class Distance : View
    {
        private void OnEnable()
        {
            EnableAction(_spawner.ChangeDistance);
        }

        private void OnDisable()
        {
            DisableAction(_spawner.ChangeDistance);
        }
    }
}
