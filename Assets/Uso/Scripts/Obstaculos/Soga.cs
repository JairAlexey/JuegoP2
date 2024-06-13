using UnityEngine; 

public class RopeManager : MonoBehaviour // Define una clase p�blica llamada RopeManager que hereda de MonoBehaviour, permiti�ndole ser usada como un componente de GameObject en Unity.
{
    public GameObject ropeSegmentPrefab; // Define un GameObject p�blico que ser� utilizado como el prefab para cada segmento de la cuerda. Los prefabs son objetos preconfigurados que puedes instanciar en tu juego.
    public Transform character1; 
    public Transform character2; 
    public int segments = 20; // Entero p�blico que define el n�mero de segmentos de la cuerda. Es inicializado a 20, pero puede ser ajustado en el editor de Unity.
    private GameObject[] ropeSegments; // Array privado de GameObjects para almacenar los segmentos de la cuerda despu�s de ser creados.

    void Start() // M�todo Start, que se llama en el primer frame antes de cualquier actualizaci�n cuando el script es activado.
    {
        CreateRope(); // Llama al m�todo CreateRope para construir la cuerda.
    }

    void CreateRope() // M�todo que contiene la l�gica para crear la cuerda entre los dos personajes.
    {
        ropeSegments = new GameObject[segments]; // Inicializa el array ropeSegments con el tama�o definido por la variable segments.
        float segmentLength = Vector2.Distance(character1.position, character2.position) / segments; // Calcula la longitud de cada segmento dividiendo la distancia total entre los dos personajes por el n�mero de segmentos.

        for (int i = 0; i < segments; i++) // Bucle for que se repite para cada segmento.
        {
            Vector2 spawnPosition = Vector2.Lerp(character1.position, character2.position, (float)i / segments); // Calcula la posici�n de cada segmento usando interpolaci�n lineal entre las posiciones de los dos personajes.
            ropeSegments[i] = Instantiate(ropeSegmentPrefab, spawnPosition, Quaternion.identity); // Instancia el prefab del segmento de la cuerda en la posici�n calculada con rotaci�n neutra (Quaternion.identity).

            if (i > 0) // Si no es el primer segmento, conecta este segmento con el anterior.
            {
                HingeJoint2D joint = ropeSegments[i].AddComponent<HingeJoint2D>(); // A�ade un componente HingeJoint2D a este segmento para poder conectarlo.
                joint.connectedBody = ropeSegments[i - 1].GetComponent<Rigidbody2D>(); // Configura el cuerpo conectado del joint al Rigidbody2D del segmento anterior.
                joint.autoConfigureConnectedAnchor = false; // Desactiva la configuraci�n autom�tica para poder establecer manualmente las posiciones de las anclas.
                joint.anchor = Vector2.zero; // Establece la ancla local en la posici�n central del segmento.
                joint.connectedAnchor = new Vector2(0, segmentLength); // Establece la ancla conectada en la posici�n que corresponde al siguiente segmento.
            }
        }

        // Conectar el primer segmento al primer personaje
        var firstJoint = ropeSegments[0].AddComponent<HingeJoint2D>(); // A�ade un HingeJoint2D al primer segmento.
        firstJoint.connectedBody = character1.GetComponent<Rigidbody2D>(); // Conecta el joint al Rigidbody2D del primer personaje.
        firstJoint.autoConfigureConnectedAnchor = false; // Desactiva la configuraci�n autom�tica de la ancla.
        firstJoint.anchor = Vector2.zero; // Establece la ancla local en la posici�n central del segmento.
        firstJoint.connectedAnchor = new Vector2(0, -0.5f); // Establece la ancla conectada en una posici�n ajustada manualmente cerca del personaje.

        // Conectar el �ltimo segmento al segundo personaje
        var lastJoint = ropeSegments[segments - 1].AddComponent<HingeJoint2D>(); // A�ade un HingeJoint2D al �ltimo segmento.
        lastJoint.connectedBody = character2.GetComponent<Rigidbody2D>(); // Conecta el joint al Rigidbody2D del segundo personaje.
        lastJoint.autoConfigureConnectedAnchor = false; // Desactiva la configuraci�n autom�tica de la ancla.
        lastJoint.anchor = Vector2.zero; // Establece la ancla local en la posici�n central del segmento.
        lastJoint.connectedAnchor = new Vector2(0, -0.5f); // Establece la ancla conectada en una posici�n ajustada manualmente cerca del personaje.
    }
}
