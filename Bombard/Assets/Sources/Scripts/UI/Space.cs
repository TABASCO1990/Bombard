namespace UI
{
    public class Space : View
    {
        private void OnEnable()
        {
            EnableAction(_spawner.ChangeSpeed);
        }

        private void OnDisable()
        {
            DisableAction(_spawner.ChangeSpeed);
        }
    }
}
