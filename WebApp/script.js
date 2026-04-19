document.addEventListener('DOMContentLoaded', () => {
    const cipherSelect = document.getElementById('cipher-select');
    const keyLabel = document.getElementById('key-label');
    const keyInput = document.getElementById('key-input');
    const messageInput = document.getElementById('message-input');
    const btnEncrypt = document.getElementById('btn-encrypt');
    const resultText = document.getElementById('result-text');

    // Update UI based on selected cipher
    cipherSelect.addEventListener('change', () => {
        const type = cipherSelect.value;
        if (type === 'caesar') {
            keyLabel.textContent = 'Przesunięcie (liczba)';
            keyInput.type = 'number';
            keyInput.placeholder = 'Np. 3';
            keyInput.value = '';
        } else if (type === 'vigenere') {
            keyLabel.textContent = 'Klucz (słowo)';
            keyInput.type = 'text';
            keyInput.placeholder = 'Np. TAJNE';
            keyInput.value = '';
        } else if (type === 'transposition') {
            keyLabel.textContent = 'Klucz (słowo bez powtórzeń)';
            keyInput.type = 'text';
            keyInput.placeholder = 'Np. KLUCZ';
            keyInput.value = '';
        }
    });

    // Run initially to set correct state
    cipherSelect.dispatchEvent(new Event('change'));

    btnEncrypt.addEventListener('click', () => {
        const type = cipherSelect.value;
        const text = messageInput.value.toUpperCase();
        let key = keyInput.value;
        let encryptedText = '';

        if (!text) {
            resultText.textContent = 'Proszę wprowadzić tekst do zaszyfrowania.';
            resultText.style.color = '#f87171';
            return;
        }

        if (!key && type !== 'caesar') { 
            resultText.textContent = 'Proszę wprowadzić klucz.';
            resultText.style.color = '#f87171';
            return;
        }
        if (type === 'caesar' && keyInput.value === '') {
            resultText.textContent = 'Proszę wprowadzić przesunięcie.';
            resultText.style.color = '#f87171';
            return;
        }

        resultText.style.color = '#34d399';

        switch (type) {
            case 'caesar':
                const shift = parseInt(key) || 0;
                encryptedText = caesarCipher(text, shift);
                break;
            case 'vigenere':
                key = key.toUpperCase().replace(/[^A-Z]/g, '');
                if (!key) {
                    resultText.textContent = 'Klucz musi zawierać litery.';
                    resultText.style.color = '#f87171';
                    return;
                }
                encryptedText = vigenereCipher(text, key);
                break;
            case 'transposition':
                key = key.toUpperCase().replace(/[^A-Z]/g, '');
                if (!key) {
                    resultText.textContent = 'Klucz musi zawierać litery.';
                    resultText.style.color = '#f87171';
                    return;
                }
                encryptedText = columnarTranspositionCipher(text.replace(/\s+/g, ''), key);
                break;
        }

        resultText.textContent = encryptedText;
        
        // Add subtle animation
        resultText.style.transform = 'scale(0.98)';
        setTimeout(() => {
            resultText.style.transform = 'scale(1)';
        }, 150);
    });

    function caesarCipher(text, shift) {
        let result = '';
        for (let i = 0; i < text.length; i++) {
            let c = text.charCodeAt(i);
            if (c >= 65 && c <= 90) {
                result += String.fromCharCode(((c - 65 + (shift % 26) + 26) % 26) + 65);
            } else {
                result += text.charAt(i);
            }
        }
        return result;
    }

    function vigenereCipher(text, key) {
        let result = '';
        let j = 0;
        for (let i = 0; i < text.length; i++) {
            let c = text.charCodeAt(i);
            if (c >= 65 && c <= 90) {
                let shift = key.charCodeAt(j % key.length) - 65;
                result += String.fromCharCode(((c - 65 + shift) % 26) + 65);
                j++;
            } else {
                result += text.charAt(i);
            }
        }
        return result;
    }

    function columnarTranspositionCipher(text, key) {
        if (!text) return '';
        
        const cols = key.length;
        const rows = Math.ceil(text.length / cols);
        
        // Create grid
        const grid = Array.from({ length: rows }, () => Array(cols).fill('X'));
        
        let k = 0;
        for (let r = 0; r < rows; r++) {
            for (let c = 0; c < cols; c++) {
                if (k < text.length) {
                    grid[r][c] = text[k++];
                }
            }
        }
        
        // Order columns based on key
        const keyOrder = key.split('').map((char, index) => ({ char, index }));
        keyOrder.sort((a, b) => a.char.localeCompare(b.char));
        
        let result = '';
        for (let i = 0; i < cols; i++) {
            const originalIndex = keyOrder[i].index;
            for (let r = 0; r < rows; r++) {
                result += grid[r][originalIndex];
            }
        }
        
        return result;
    }
});
