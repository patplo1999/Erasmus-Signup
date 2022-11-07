const openInNewTab = (url: string): void => {
  window.open(url, "_blank", "noopener,noreferrer");
}

export default openInNewTab;