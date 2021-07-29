<template>
  <div class="step">
    <div class="step__wrapper">
      <div class="step-container">
        <div :class="activate(i)" v-for="i in steps" :key="i" class="step">
          {{ i }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "StepBar",
  props: {
    steps: {
      type: Number,
    },
    currentStep: {
      type: Number,
    },
  },
  methods: {
    activate(i) {
      if (this.currentStep >= i) {
        return "active";
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.step {
  width: 100%;
}

.step-container {
  display: flex;
  max-width: 366px;
  width: 100%;
  margin: 0 auto;
  justify-content: space-between;
  margin-top: 16px;

  .step {
    border-radius: 50%;
    width: 40px;
    height: 40px;
    display: flex;
    justify-content: center;
    align-items: center;
    position: relative;
    font-size: 24px;
    text-align: center;
    background: #eef0f5;
    color: #c4c4c4;

    &.active {
      background: #30aec4;
      color: #fff;

      &::after {
        border-color: #53C8E1;
      }
    }

    &::after {
      content: "";
      position: absolute;
      height: 1px;
      left: 112%;
      width: 107px;
      border-top: 1px solid #eef0f5;
    }

    &:last-child::after {
      border-top: none;
    }
  }
}
</style>
