using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSlideshow : MonoBehaviour
{
    [Header("Slideshow Settings")]
    [SerializeField] private Image displayImage; // Reference to UI Image component
    [SerializeField] private Sprite[] slides; // Array of sprites to display
    [SerializeField] private float secondsPerSlide = 3f; // How long to show each slide
    [SerializeField] private bool autoPlay = true; // Whether to automatically advance slides
    [SerializeField] private bool loop = true; // Whether to loop back to start after last slide
    [SerializeField] private int nextSceneIndex = 0; // Scene to load when slideshow finishes

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource; // Reference to AudioSource component
    [SerializeField] private AudioClip transitionSound; // Sound to play between slides

    private int currentSlideIndex = 0;
    private float timer = 0f;

    private void Start()
    {
        // Add AudioSource if not already present
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (slides.Length > 0)
        {
            // Show first slide
            displayImage.sprite = slides[0];
        }
        else
        {
            Debug.LogWarning("No slides assigned to ImageSlideshow!");
        }
    }

    private void Update()
    {
        if (!autoPlay || slides.Length <= 1) return;

        timer += Time.deltaTime;

        if (timer >= secondsPerSlide)
        {
            NextSlide();
            timer = 0f;
        }
    }

    private void PlayTransitionSound()
    {
        if (audioSource != null && transitionSound != null)
        {
            audioSource.PlayOneShot(transitionSound);
        }
    }

    public void NextSlide()
    {
        if (slides.Length <= 1) return;

        currentSlideIndex++;
        
        if (currentSlideIndex >= slides.Length)
        {
            if (loop)
            {
                currentSlideIndex = 0;
            }
            else
            {
                currentSlideIndex = slides.Length - 1;
                autoPlay = false;
                // Load the next scene when slideshow finishes
                SceneManager.LoadScene(nextSceneIndex);
                return;
            }
        }

        PlayTransitionSound();
        displayImage.sprite = slides[currentSlideIndex];
    }

    public void PreviousSlide()
    {
        if (slides.Length <= 1) return;

        currentSlideIndex--;
        
        if (currentSlideIndex < 0)
        {
            if (loop)
            {
                currentSlideIndex = slides.Length - 1;
            }
            else
            {
                currentSlideIndex = 0;
                return;
            }
        }

        PlayTransitionSound();
        displayImage.sprite = slides[currentSlideIndex];
    }

    // Manually set which slide to display (0-based index)
    public void SetSlide(int index)
    {
        if (index >= 0 && index < slides.Length)
        {
            currentSlideIndex = index;
            displayImage.sprite = slides[currentSlideIndex];
            PlayTransitionSound();
            timer = 0f;
        }
    }

    // Toggle auto-play
    public void ToggleAutoPlay()
    {
        autoPlay = !autoPlay;
        timer = 0f;
    }
}
